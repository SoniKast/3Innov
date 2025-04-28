import { fileURLToPath, URL } from 'node:url';

import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import fs from 'fs';
import path from 'path';
import child_process from 'child_process';
import { env } from 'process';

const baseFolder =
    env.APPDATA !== undefined && env.APPDATA !== ''
        ? `${env.APPDATA}/ASP.NET/https`
        : `${env.HOME}/.aspnet/https`;

if (!fs.existsSync(baseFolder)) {
    fs.mkdirSync(baseFolder, { recursive: true });
}

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7075';

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [plugin()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        proxy: {
<<<<<<< Updated upstream
            '^/weatherforecast': {
                target,
                secure: false
            }
        },
        port: 51325,
        https: false,
=======
            '/api': {
                target: 'http://localhost:5000',  // Target your backend container
                changeOrigin: true,
                secure: false,
            }
        },
        port: 3000,  // Use standard port for frontend inside Docker
        https: false, // Make sure it stays HTTP
        host: 'admininterface.client', // node container in docker (container name)
        origin: 'http://localhost:3000', // exposed node container address
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }
})
