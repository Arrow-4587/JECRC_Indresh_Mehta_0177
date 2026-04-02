import { BrowserRouter, Routes, Route, NavLink } from "react-router-dom";
import Home from "./pages/Home";
import About from "./pages/About";
import Contact from "./pages/Contact";

function App() {
    return (
        <BrowserRouter>
            <nav style={styles.nav}>
                <NavLink to="/" style={styles.link} end>Home</NavLink>
                <NavLink to="/About" style={styles.link}>About</NavLink>
                <NavLink to="/Contact" style={styles.link}>Contact</NavLink>
            </nav>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/About" element={<About />} />
                <Route path="/Contact" element={<Contact />} />
            </Routes>
        </BrowserRouter>
    );
}

const styles = {
    nav: {
        display: 'flex',
        gap: '20px',
        padding: '15px',
        background: '#eee',
        justifyContent: 'center'
    },
    link: ({ isActive }) => ({
        textDecoration: 'none',
        color: isActive ? 'red' : 'black',
        fontWeight: isActive ? 'bold' : 'normal'
    })
};

export default App;