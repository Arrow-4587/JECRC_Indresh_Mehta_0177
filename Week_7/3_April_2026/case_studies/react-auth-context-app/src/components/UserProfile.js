import React from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/authContext";

function UserProfile ()
{
    const {user, logout} = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => 
    {
        logout();
        navigate("/login");
    }
    return (
        <div>
            <h2>User Profile</h2>
            <p>Welcome, {user.username}!</p>
            <button onClick={handleLogout}>Logout</button>
        </div>
    );
}
export default UserProfile;