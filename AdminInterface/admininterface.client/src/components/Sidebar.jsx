import React from 'react';
import { Link } from 'react-router-dom';
import DropdownMenu from './DropdownMenu';
import "../App.css";

const Sidebar = () => {
    
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
                            { label: "Créer un ticket", path: "/create-ticket" },
                            { label: "Tickets", path: "/tickets" },
                            { label: "Monitoring", path: "/monitoring" }
                        ]}
                    />
                </li>
                <li className="nav-item">
                    <DropdownMenu
                        title="Administration"
                        links={[
                            { label: "Gérer utilisateurs", path: "/users" },
                            { label: "Statistiques", path: "/stats" },
                            { label: "Paramètres avancés", path: "/advanced-settings" }
                        ]}
                    />
                </li>
                <li className="nav-item">
                    <Link to="/settings" className="bg-light text-center nav-link link-secondary">Paramètres</Link>
                </li>
                <li className="nav-item">
                    <Link to="/logout" className="bg-light text-center nav-link link-secondary">Déconnexion</Link>
                </li>
            </ul>
        </aside>
    );
};

export default Sidebar;
