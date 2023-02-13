import React from "react";
import { betwayLogo } from "./constants";
import styles from "./style";
import Navbar from "./components/Navbar";
import CTA from "./components/CTA";

const App = () => {
  return (
    <div className="bg-primary w-full overflow-hidden">
      <div className="flex flex-row pt-2">
        <img
          src={betwayLogo}
          alt="betway"
          className="w-[120px] pt-3 px-1 ml-2"
        />
        <div className="w-full flex flex-row-reverse">
          <button className="btn btn-secondary xs:mr-4">Sign up</button>
          <button className="btn btn-primary xs:mr-1">Login</button>
        </div>
      </div>
      <div className={`${styles.paddingX} ${styles.flexStart}`}>
        <div className={`${styles.boxWidth}`}>
          <Navbar />
        </div>
      </div>

      <div
        className={`bg-primary w-full bg-hero bg-no-repeat bg-cover bg-center`}
      >
        <div className={`w-full ${styles.boxWidth} flex flex-col h-[80vh]`}>
          <CTA />
        </div>
      </div>
    </div>
  );
};

export default App;
