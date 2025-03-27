import { React, useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

const Header = () => {
    const [estConnecte, setConnecte] = useState(false);

    useEffect(() => {
        const token = localStorage.getItem("token"); 
        if (token) {
            setConnecte(true);
        }
    }, []);
    return (
        <header className="w-100">
            <div className="bg-danger">
                <div className="container d-flex flex-wrap justify-content-between py-3">
                    <a href="/" className="d-flex align-items-center mb-3 mb-md-0 me-auto link-body-emphasis text-decoration-none">
                        <span className="fs-4 text-light">Gestiam</span>
                    </a>
                    <div className="text-end">
                        {estConnecte ? (
                            <h4 className="text-light font-weight-bold">Vous êtes bien connecté.</h4>
                        ) : (
                            <Link to="/login">
                                <button type="button" className="btn btn-outline-light me-2">Se connecter</button>
                            </Link>
                        )}
                    </div>
                </div>
            </div>

        </header>
    );
}

export default Header;
