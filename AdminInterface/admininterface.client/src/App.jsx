import React, { useState, useEffect } from 'react';
import { Routes, Route, useLocation } from 'react-router-dom';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import ProtectedRoute from './components/ProtectedRoute';
import PageRoutes from './components/PageRoutes';
import Ping from './components/Ping';
import EditUser from './pages/EditUser';
import Login from './pages/Login';
import EditEquipement from './pages/EditEquipment';
import EditTicket from './pages/EditTicket';
import LoadingSpinner from './components/LoadingSpinner';

const App = () => {
    const location = useLocation();
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        setLoading(true);
        const timeout = setTimeout(() => setLoading(false), 300); // delay to simulate transition
        return () => clearTimeout(timeout);
    }, [location.pathname]);

    const hideSidebar = ["/login"];
    const showSidebar = !hideSidebar.includes(location.pathname); // Afficher le sidebar partout sauf la page de connexion

    return loading ? (
        <LoadingSpinner />
    ) : (
        <div className="app-container">
            <Header />
            <div className="d-flex">
                {showSidebar && < Sidebar />}
                <div className="container p-3 justify-content-center">
                    <Routes>
                        {PageRoutes.map((PageRoutes, index) => (
                            <Route key={index} path={PageRoutes.path} element={
                                <ProtectedRoute>
                                    <PageRoutes.component />
                                </ProtectedRoute>
                            } />
                        ))}
                        <Route path="/monitoring/:id/ping" element={
                            <ProtectedRoute>
                                <Ping />
                            </ProtectedRoute>
                        } />
                        <Route path="/monitoring/:id/edit" element={
                            <ProtectedRoute>
                                <EditEquipement />
                            </ProtectedRoute>
                        } />
                        <Route path='/utilisateurs/:id/edit' element={
                            <ProtectedRoute>
                                <EditUser />
                            </ProtectedRoute>
                        } />
                        <Route path='/tickets/:id/edit' element={
                            <ProtectedRoute>
                                <EditTicket />
                            </ProtectedRoute>
                        } />
                        <Route path="/login" element={<Login />} />
                    </Routes>
                </div>
            </div>
        </div>
    );
};

export default App;