import React from 'react';

const LoadingSpinner = () => (
    <div className="main-page container mt-4">
        <div className="d-flex justify-content-center align-items-center" style={{ height: '100vh', width: '100vh' }}>
            <div className="spinner-border text-danger" role="status">
                <span className="visually-hidden">Chargement...</span>
            </div>
        </div>
    </div>
);

export default LoadingSpinner;