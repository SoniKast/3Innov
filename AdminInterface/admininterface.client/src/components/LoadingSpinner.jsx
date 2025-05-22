import React from 'react';

const LoadingSpinner = () => (
    <div
        style={{
            position: 'fixed',
            top: 0,
            left: 0,
            height: '100vh',
            width: '100vw',
            backgroundColor: 'rgba(255, 255, 255, 0.8)', // léger fond blanc semi-transparent
            zIndex: 9999,
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center'
        }}
    >
        <div className="spinner-border text-danger" role="status">
            <span className="visually-hidden">Chargement...</span>
        </div>
    </div>
);

export default LoadingSpinner;