import { Outlet, Link } from "react-router-dom";

function MainLayout() {
  return (
    <div>
      <header>
        <h2>E-Commerce</h2>
        <nav>
          <Link to="/">Home</Link> | 
          <Link to="/about">About</Link> | 
          <Link to="/contact">Contact</Link> | 
          <Link to="/products">Products</Link>
        </nav>
      </header>

      <Outlet />

      <footer>© 2026 Company</footer>
    </div>
  );
}

export default MainLayout;
