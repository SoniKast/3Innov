import { fileURLToPath, URL } from 'node:url';
import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';

// https://vitejs.dev/config/
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
        }
    }
});
