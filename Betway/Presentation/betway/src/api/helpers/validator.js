export const validator = (username, password) => {
  const errors = [];

  if (username.length === 0) {
    errors.push({ property: "username", message: "username can't be empty" });
  }

  if (password.length === 0) {
    errors.push({ property: "password", message: "password can't be empty" });
  }

  if (username.split("").filter((x) => x === "@").length !== 1) {
    errors.push({ property: "username", message: "Email should contain a @" });
  }
  if (username.indexOf(".") === -1) {
    errors.push({
      property: "username",
      message: "Email should contain at least one dot",
    });
  }

  if (password.length < 8) {
    errors.push({
      property: "password",
      message: "Password should be at least 8 characters long",
    });
  }

  return errors;
};
