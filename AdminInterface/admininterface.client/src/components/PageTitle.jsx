import { useEffect } from 'react';
import { useLocation } from 'react-router-dom';
import PageRoutes from './PageRoutes';

function PageTitle() {
    const location = useLocation();

    useEffect(() => {
        const currentRoute = PageRoutes.find(route => route.path === location.pathname);
        if (currentRoute) {
            document.title = currentRoute.name + " - Gestiam";
        } else {
            document.title = 'Gestiam';
        }
    }, [location]);

    return null;
}

export default PageTitle;