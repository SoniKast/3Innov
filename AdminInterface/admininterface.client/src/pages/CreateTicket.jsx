import React, { useState } from 'react';

function CreateTicket() {
    // Déclaration des états
    const [title, setTitle] = useState('');
    const [description, setDescription] = useState('');
    const [type, setType] = useState('low');
    const [error, setError] = useState('');

    // Fonction pour envoyer le ticket
    const handleSubmit = (e) => {
        e.preventDefault();

        // Vérification des champs obligatoires
        if (!title || !description) {
            setError('Le titre et la description sont obligatoires.');
            return;
        }

        // Préparer le ticket à envoyer (exemple)
        const ticket = { title, description, type };

        // Vous pouvez envoyer ce ticket à votre API
        console.log('Ticket créé:', ticket);

        // Effacer les champs après soumission
        setTitle('');
        setDescription('');
        setType('bug');
        setError('');
    };

    return (
        <div className="main-page">
            <div className="container mt-5">
                <h2 className="text-center mb-4">Créer un Ticket</h2>
                {error && <div className="alert alert-danger">{error}</div>}
                <form onSubmit={handleSubmit}>
                    {/* Titre du ticket */}
                    <div className="form-group">
                        <label htmlFor="ticketTitle">Titre du Ticket</label>
                        <input
                            type="text"
                            className="form-control"
                            id="ticketTitle"
                            placeholder="Entrez le titre"
                            value={title}
                            onChange={(e) => setTitle(e.target.value)}
                            required
                        />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="ticketDescription">Description</label>
                        <textarea
                            className="form-control"
                            id="ticketDescription"
                            rows="4"
                            placeholder="Entrez la description du ticket"
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            required
                        />
                    </div>

                    <div className="form-group mt-3">
                        <label htmlFor="ticketType">Type</label>
                        <select
                            className="form-control"
                            id="ticketType"
                            value={type}
                            onChange={(e) => setType(e.target.value)}
                        >
                            <option value="bug">Bug</option>
                            <option value="maintenance">Maintenance</option>
                            <option value="amelioration">Amélioration</option>
                        </select>
                    </div>

                    {/* Bouton de soumission */}
                    <div className="text-center mt-4">
                        <button type="submit" className="btn btn-primary">Créer le Ticket</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default CreateTicket;
