import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';

export default defineConfig({
    plugins: [plugin()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        proxy: {
            '/api': {
                target: 'http://172.17.0.1:5000',  // Target your backend container
                changeOrigin: true,
                secure: false,
            }
        },
        port: 3000,  // Use standard port for frontend inside Docker
        https: false, // Make sure it stays HTTP
        host: 'admininterface.client', // node container in docker (container name)
        origin: 'http://localhost:3000', // exposed node container address
    }
})
