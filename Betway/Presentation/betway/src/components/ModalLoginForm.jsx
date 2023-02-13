import React from "react";
import Button from "@mui/material/Button";
import TextField from "@mui/material/TextField";
import Dialog from "@mui/material/Dialog";
import DialogActions from "@mui/material/DialogActions";
import DialogContent from "@mui/material/DialogContent";
import DialogContentText from "@mui/material/DialogContentText";
import DialogTitle from "@mui/material/DialogTitle";
import axios from "axios";
import { Typography } from "@mui/material";
import { validator } from "../api/helpers/validator";
import { useEffect } from "react";
import { useCallback } from "react";

const ModalLoginForm = (props) => {
  const { isCtaClicked } = props;
  const [open, setOpen] = React.useState(isCtaClicked);
  const [show, setShow] = React.useState(false);
  const [errors, setErrors] = React.useState([]);
  const [username, setUsername] = React.useState("");
  const [password, setPassword] = React.useState("");
  const [usernameHasError, setUsernameHasError] = React.useState(false);
  const [passwordHasError, setPasswordHasError] = React.useState(false);
  const [errorText, setErrorText] = React.useState("");

  useEffect(() => {
    initValidation();
  }, []);

  const initValidation = useCallback(() => {
    let errs = validator(username, password);

    if (errs.length > 0) {
      setErrors(errs);

      let usnmErr = errs.find((err) => err.property === "username");
      if (usnmErr) setUsernameHasError(true);

      let pwdErr = errs.find((err) => err.property === "password");
      if (pwdErr) setPasswordHasError(true);
    }
  }, []);

  const handleLogin = () => {
    if (errors.length > 0) return;

    const userDetails = {
      email: username,
      password: password,
    };

    axios
      .post("https://localhost:44354/api/Account", userDetails, {
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
          "Access-Control-Allow-Origin": "*",
        },
      })
      .then((response) => {
        console.log(response);
        setOpen(false);
        setShow(true);
      })
      .catch((err) => {
        console.log(err);

        if (err.response.status == 403) {
          setErrorText(err.data);
        } else {
          const errs = err.response.data;

          setErrors(errs);

          let usnmErr = errs.find((err) => err.property === "username");
          if (usnmErr) setUsernameHasError(true);

          let pwdErr = errs.find((err) => err.property === "password");
          if (pwdErr) setPasswordHasError(true);
        }
      });

    //if(response)
    //setOpen(false);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleInputChange = (event) => {
    const property = event.target.id;
    let email = username;
    let pwd = password;

    if (property === "email") {
      email = event.target.value;
      setUsername(email);
    } else {
      pwd = event.target.value;
      setPassword(pwd);
    }

    const err = validator(email, pwd);

    if (err) {
      setErrors(err);
      let usnmErr = err.find((err) => err.property === "username");
      if (usnmErr) setUsernameHasError(true);
      else setUsernameHasError(false);

      let pwdErr = err.find((err) => err.property === "password");
      if (pwdErr) setPasswordHasError(pwdErr != undefined);
      else setPasswordHasError(false);
    }
  };

  const getErrorMessage = (property) => {
    let verr = errors.find((err) => err.property === property);

    // setUsernameHasError(property === "username" && verr);
    // setPasswordHasError(property === "password" && verr);

    let message = "";
    if (verr != undefined) message = verr["message"];

    return message;
  };

  return (
    <div>
      <Dialog
        open={open}
        onClose={() => setOpen(false)}
        fullWidth
        sx={{
          paddingBottom: "30px",
        }}
      >
        <DialogTitle>
          <div className="flex flex-col justify-center">
            <span className="flex justify-center font-bold text-[26px]">
              Login
            </span>
            <span className="flex justify-center text-[12px]">
              New customer?{" "}
              <a href="#" className=" text-[#00a826]">
                Register here.
              </a>
            </span>
          </div>
        </DialogTitle>
        <DialogContent>
          <TextField
            required
            autoFocus
            margin="dense"
            id="email"
            label="Username"
            type="email"
            fullWidth
            variant="standard"
            error={usernameHasError == true}
            helperText={`${getErrorMessage("username")}`}
            onChange={handleInputChange}
          />
          <TextField
            required
            margin="dense"
            id="password"
            label="Password"
            type="password"
            fullWidth
            variant="standard"
            error={passwordHasError == true}
            helperText={`${getErrorMessage("password")}`}
            onChange={handleInputChange}
          />

          {errorText && (
            <Typography sx={{ color: "red" }}>{errorText}</Typography>
          )}
        </DialogContent>
        <DialogActions sx={{ justifyContent: "center" }}>
          <Button
            onClick={handleLogin}
            sx={{
              backgroundColor: "#00a826",
              width: 200,
              borderRadius: "none",
              color: "white",
              fontWeight: "600",
              padding: "10px",
              ":hover": {
                border: "1px solid #00a826",
                backgroundColor: "white",
                color: "#00a826",
              },
            }}
          >
            Login
          </Button>
        </DialogActions>
        <div className="flex flex-col justify-center">
          <span className="flex justify-center font-bold font-popins text-sm text-[#00a826]">
            Forgot Username/Password
          </span>
        </div>
      </Dialog>

      <Dialog
        open={show}
        onClose={() => setShow(false)}
        aria-labelledby="responsive-dialog-title"
      >
        <DialogTitle id="responsive-dialog-title">{"Welcome!"}</DialogTitle>
        <DialogContent>
          <DialogContentText>{"Welcome at Betway"}</DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setShow(false)} autoFocus>
            Ok
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default ModalLoginForm;
