import React, { useState } from "react";
import "./ThemeToggle.css";



function ThemeToggle() {
  const [isDark, setIsDark] = useState(false);

  const toggleTheme = () => {
    setIsDark(!isDark);
  };

  return (
    // <div style={isDark ? darkStyle : lightStyle}>
      
    //   {/* Mode Display */}
    //   <h2>Mode: {isDark ? "Dark" : "Light"}</h2>

    //   {/* Toggle Button */}
    //   <button onClick={toggleTheme} style={buttonStyle}>
    //     Switch to {isDark ? "Light" : "Dark"} Mode
    //   </button>

    // </div>

    <div className={`container ${isDark ? "dark" : "light"}`}>
  <h2 className="title">Mode: {isDark ? "Dark" : "Light"}</h2>

  <button className="button" onClick={toggleTheme}>
    Switch to {isDark ? "Light" : "Dark"} Mode
  </button>
</div>
  );
}

const lightStyle = {
  backgroundColor: "#ffffff",
  color: "#000000",
  height: "100vh",
  display: "flex",
  flexDirection: "column",
  justifyContent: "center",
  alignItems: "center",
};

const darkStyle = {
  backgroundColor: "#121212",
  color: "#ffffff",
  height: "100vh",
  display: "flex",
  flexDirection: "column",
  justifyContent: "center",
  alignItems: "center",
};

const buttonStyle = {
  padding: "10px 20px",
  fontSize: "16px",
  marginTop: "20px",
  cursor: "pointer",
  borderRadius: "6px",
  border: "none",
  backgroundColor: "#007bff",
  color: "white",
};

export default ThemeToggle;
