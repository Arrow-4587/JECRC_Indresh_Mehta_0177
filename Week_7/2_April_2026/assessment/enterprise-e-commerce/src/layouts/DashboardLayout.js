import { Outlet, Link } from "react-router-dom";

function DashboardLayout() {
  return (
    <div>
      <h2>Dashboard</h2>

      <nav>
        <Link to="/dashboard">Home</Link> | 
        <Link to="/dashboard/analytics">Analytics</Link> | 
        <Link to="/dashboard/settings">Settings</Link>
      </nav>

      <Outlet />
    </div>
  );
}

export default DashboardLayout;
