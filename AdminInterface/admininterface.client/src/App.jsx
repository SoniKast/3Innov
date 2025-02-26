import { useEffect, useState } from 'react';
import { Routes, Route } from 'react-router-dom';
import Header from './components/Header';
import Footer from './components/Footer';
import Home from './pages/Home';
import Monitoring from './pages/Monitoring.jsx';
import Tickets from './pages/Tickets.jsx';
import Register from './pages/Register.jsx';
import Login from './pages/Login.jsx';
import Dashboard from './pages/Dashboard.jsx';

const App = () => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(() => {
        // Check if the user is authenticated (e.g., by checking if a token exists in localStorage)
        const token = localStorage.getItem('token');
        if (token) {
            setIsAuthenticated(true);
        }
    }, []);

    const handleLogout = () => {
        localStorage.removeItem('token');
        setIsAuthenticated(false);
    };

    return (
        <div className="app-container">
            <Header isAuthenticated={isAuthenticated} onLogout={handleLogout} />
            <div className="content">
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/monitoring" element={<Monitoring />} />
                    <Route path="/tickets" element={<Tickets />} />
                    <Route path="/dashboard" element={<Dashboard />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/login" element={<Login />} />
                </Routes>
            </div>
            <Footer />
        </div>
    );
};

export default App;