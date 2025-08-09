import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';

import Navbar from './components/UI/Navbar';
import Sidebar from './components/UI/Sidebar';

import Home from './pages/Home';
import Tamales from './pages/Productos/Tamales';
import Bebidas from './pages/Productos/Bebidas';
import Combos from './pages/Productos/Combos';
import Inventario from './pages/Inventario';
import Ventas from './pages/Ventas';
import Sucursales from './pages/Sucursales';
import Notificaciones from './pages/Notificaciones';
import Configuracion from './pages/Configuracion';

function App() {
  return (
    <Router>
      <Navbar />
      <div style={{ display: 'flex' }}>
        <Sidebar />
        <main style={{ flexGrow: 1, padding: '1rem' }}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/tamales" element={<Tamales />} />
            <Route path="/bebidas" element={<Bebidas />} />
            <Route path="/combos" element={<Combos />} />
            <Route path="/inventario" element={<Inventario />} />
            <Route path="/ventas" element={<Ventas />} />
            <Route path="/sucursales" element={<Sucursales />} />
            <Route path="/notificaciones" element={<Notificaciones />} />
            <Route path="/configuracion" element={<Configuracion />} />
            <Route path="*" element={<Navigate to="/" replace />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}

export default App;
