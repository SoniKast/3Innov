import { fileURLToPath, URL } from 'node:url';
import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';

const isDocker = process.env.DOCKER === 'true';


export default defineConfig({
    plugins: [plugin()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        port: 3000,  // Use standard port for frontend inside Docker
        https: false, // Make sure it stays HTTP
        proxy: {
            '/api': {
                target: 'http://admininterface.server:80',  // Target your backend container
                changeOrigin: true,
                secure: false,
            }
        },
		host: isDocker ? 'admininterface.client' : 'localhost',
		origin: isDocker ? 'http://admininterface.client:3000' : 'http://localhost:3000',
		cors: true,
    },
	assetsInclude: ['**/*.woff', '**/*.woff2']
});
