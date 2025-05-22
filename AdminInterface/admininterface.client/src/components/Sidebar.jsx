import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import DropdownMenu from './DropdownMenu';
import "../App.css";

const Sidebar = () => {
    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.removeItem("token"); // Remove the token from local storage
        window.location.reload(); // Refresh the page to reset authentication state
        navigate("/login"); // Redirect to the login page after logout
    };

    return (
        <aside className="bg-danger vh-100" style={{ width: '250px' }}>
            <ul className="nav flex-column">
                <li className="nav-item">
                    <Link to="/" className="bg-light text-center nav-link link-secondary">Accueil</Link>
                </li>
                <li className="nav-item">
                    <DropdownMenu
                        title="Assistance"
                        links={[
                            { label: "+ Tickets", path: "/tickets" },
                            { label: "+ Monitoring", path: "/monitoring" }
                        ]}
                    />
                </li>
                <li className="nav-item">
                    <DropdownMenu
                        title="Administration"
                        links={[
                            { label: "+ Créer un ticket", path: "/create-ticket" },
                            { label: "+ Enregistrer un équipement", path: "/register-equipment" },
                            { label: "+ Gérer utilisateurs", path: "/utilisateurs" },
                            { label: "+ Créer un utilisateur", path: "/create-user" },
                            { label: "+ Statistiques", path: "/stats" },
                        ]}
                    />
                </li>
                <li className="nav-item">
                    <button className="bg-light text-center nav-link link-secondary border-0 w-100" onClick={handleLogout}>Déconnexion</button>
                </li>
            </ul>
        </aside>
    );
};

export default Sidebar;
