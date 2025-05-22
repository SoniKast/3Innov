import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import PageRoutes from './PageRoutes';

const Header = () => {
    const [estConnecte, setConnecte] = useState(false);
    const [email, setEmail] = useState('');
    const [searchTerm, setSearchTerm] = useState("");
    const [filteredPages, setFilteredPages] = useState([]);

    useEffect(() => {
        const token = localStorage.getItem("token") || sessionStorage.getItem("token");
        if (token) {
            try {
                const base64Url = token.split('.')[1];
                const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
                const jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
                    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
                }).join(''));
                const decoded = JSON.parse(jsonPayload);

                setEmail(decoded.email || decoded[Object.keys(decoded).find(k => k.toLowerCase().includes('email'))]);
                setConnecte(true);
            } catch (e) {
                console.error("Token parsing error:", e);
                setConnecte(false);
            }
        }
    }, []);

    useEffect(() => {
        if (searchTerm.trim() === '') {
            setFilteredPages([]);
        } else {
            const results = PageRoutes.filter(r =>
                r.name.toLowerCase().includes(searchTerm.toLowerCase())
            );
            setFilteredPages(results);
        }
    }, [searchTerm]);

    return (
        <header className="w-100">
            <div className="bg-danger">
                <div className="container-fluid d-flex flex-wrap justify-content-between py-3 px-4">
                    <a href="/" className="d-flex align-items-center mb-3 mb-md-0 me-auto link-body-emphasis text-decoration-none">
                        <span className="fs-4 text-light">Gestiam</span>
                    </a>
                    <div className="position-relative me-3">
                        {estConnecte && ( 
							<> 
							<input
								type="text"
								className="form-control"
								placeholder="Rechercher une page..."
								value={searchTerm}
								onChange={(e) => setSearchTerm(e.target.value)}
							/>
							{filteredPages.length > 0 && (
								<ul className="list-group position-absolute w-100 z-3">
									{filteredPages.map((page, index) => (
										<Link
											key={index}
											to={page.path}
											className="list-group-item list-group-item-action"
											onClick={() => setSearchTerm('')}
										>
											{page.name}
										</Link>
									))}
								</ul>
							)}
						 </>
                       )} 
                    </div>
                    <div className="text-end align-middle">
                        {estConnecte ? (
                            <span className="text-light font-weight-bold">Connecté en tant que : <strong>{email}</strong></span>
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
};

export default Header;
