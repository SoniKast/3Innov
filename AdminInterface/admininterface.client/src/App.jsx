import React from 'react';
import { Routes, Route, useLocation } from 'react-router-dom';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import ProtectedRoute from './components/ProtectedRoute';
import Home from './pages/Home';
import Monitoring from './pages/Monitoring';
import Tickets from './pages/Tickets';
import Register from './pages/Register';
import Ping from './components/Ping';
import Login from './pages/Login';
import CreateTicket from './pages/CreateTicket';
import Utilisateurs from './pages/Utilisateurs';

const App = () => {
    const location = useLocation();

    const hideSidebar = ["/login"];
    const showSidebar = !hideSidebar.includes(location.pathname); // Afficher le sidebar partout sauf la page de connexion

    return (
        <div className="app-container">
            <Header />
            <div className="d-flex">
                {showSidebar && < Sidebar />}
                <div className="container p-3 justify-content-center">
                    <Routes>
                        <Route path="/" element={
                            <ProtectedRoute>
                                <Home />
                            </ProtectedRoute>
                        } />
                        <Route path="/monitoring" element={
                            <ProtectedRoute>
                                <Monitoring />
                            </ProtectedRoute>
                        } />
                        <Route path="/monitoring/:id/ping" element={
                            <ProtectedRoute>
                                <Ping />
                            </ProtectedRoute>
                        } />
                        <Route path="/tickets" element={
                            <ProtectedRoute>
                                <Tickets />
                            </ProtectedRoute>
                        } />
                        <Route path="/create-ticket" element={
                            <ProtectedRoute>
                                <CreateTicket />
                            </ProtectedRoute>
                        } />
                        <Route path="/utilisateurs" element={
                            <ProtectedRoute>
                                <Utilisateurs />
                            </ProtectedRoute>
                        } />
                        <Route path="/register" element={<Register />} />
                        <Route path="/login" element={<Login />} />
                    </Routes>
                </div>
            </div>
        </div>
    );
};

export default App;