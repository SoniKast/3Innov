import React from 'react';
import { Routes, Route, useLocation } from 'react-router-dom';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import Home from './pages/Home';
import Monitoring from './pages/Monitoring';
import Tickets from './pages/Tickets';
import Register from './pages/Register';
import Login from './pages/Login';
import Dashboard from './pages/Dashboard';

const App = () => {
    const location = useLocation();

    const hideSidebar = ["/login"];
    const showSidebar = !hideSidebar.includes(location.pathname); // Afficher le sidebar partout sauf
    // la page de connexion

    return (
        <div className="app-container">
            <Header />
            <div className="d-flex">
                {showSidebar && < Sidebar />}
                <div className="container p-3 justify-content-center">
                    <Routes>
                        <Route path="/" element={<Home />} />
                        <Route path="/monitoring" element={<Monitoring />} />
                        <Route path="/tickets" element={<Tickets />} />
                        <Route path="/dashboard" element={<Dashboard />} />
                        <Route path="/register" element={<Register />} />
                        <Route path="/login" element={<Login />} />
                    </Routes>
                </div>
            </div>
        </div>
    );
};

export default App;