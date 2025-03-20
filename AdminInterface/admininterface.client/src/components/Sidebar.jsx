import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import "../App.css";

const Sidebar = () => {
    // State to track dropdown visibility
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);

    // Function to toggle dropdown
    const toggleDropdown = () => {
        setIsDropdownOpen(!isDropdownOpen);
    };

    return (
        <aside className="bg-danger vh-100" style={{ width: '250px' }}>
            <ul className="nav flex-column">
                <li className="nav-item">
                    <Link to="/" className="bg-light text-center nav-link link-secondary">Accueil</Link>
                </li>
                <li className="nav-item">
                    <div
                        className="bg-light text-center nav-link link-secondary dropdown-btn pe-auto"
                        onClick={toggleDropdown}
                    >
                        Assistance
                    </div>
                    <div
                        className="dropdown-container"
                        style={{ display: isDropdownOpen ? "block" : "none" }}>
                        <ul>
                            <li><Link to="#">Link 1</Link></li>
                            <li><Link to="#">Link 2</Link></li>
                            <li><Link to="#">Link 3</Link></li>
                        </ul>
                    </div>
                </li>
                <li className="nav-item">
                    <Link to="/dashboard" className="bg-light text-center nav-link link-secondary">Administration</Link>
                </li>
                <li className="nav-item">
                    <Link to="/settings" className="bg-light text-center nav-link link-secondary">Settings</Link>
                </li>
                <li className="nav-item">
                    <Link to="/logout" className="bg-light text-center nav-link link-secondary">Déconnexion</Link>
                </li>
            </ul>
        </aside>
    );
};

export default Sidebar;
