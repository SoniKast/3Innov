import React from 'react';
import { Routes, Route, useLocation } from 'react-router-dom';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import ProtectedRoute from './components/ProtectedRoute';
import PageRoutes from './components/PageRoutes';
import EditUser from './pages/EditUser';
import Register from './pages/Register';
import Login from './pages/Login';

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
                        <Route path='/utilisateurs/:id/edit' element={<EditUser />} />,
                        <Route path="/register" element={<Register />} />
                        <Route path="/login" element={<Login />} />
                    </Routes>
                </div>
            </div>
        </div>
    );
};

export default App;