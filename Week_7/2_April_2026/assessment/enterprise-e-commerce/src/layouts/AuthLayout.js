import { Outlet } from "react-router-dom";

function AuthLayout() {
  return (
    <div style={{ textAlign: "center", marginTop: "100px" }}>
      <Outlet />
    </div>
  );
}

export default AuthLayout;
