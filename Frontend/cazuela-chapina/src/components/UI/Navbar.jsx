import React from 'react';
import { Link } from 'react-router-dom';

export default function Navbar() {
  return (
    <nav style={{ background: '#333', padding: '1rem', color: 'white' }}>
      <Link to="/" style={{ color: 'white', marginRight: '1rem' }}>Inicio</Link>
      <Link to="/tamales" style={{ color: 'white', marginRight: '1rem' }}>Tamales</Link>
      <Link to="/bebidas" style={{ color: 'white', marginRight: '1rem' }}>Bebidas</Link>
      <Link to="/combos" style={{ color: 'white', marginRight: '1rem' }}>Combos</Link>
      <Link to="/inventario" style={{ color: 'white', marginRight: '1rem' }}>Inventario</Link>
      <Link to="/ventas" style={{ color: 'white', marginRight: '1rem' }}>Ventas</Link>
      <Link to="/sucursales" style={{ color: 'white', marginRight: '1rem' }}>Sucursales</Link>
      <Link to="/notificaciones" style={{ color: 'white', marginRight: '1rem' }}>Notificaciones</Link>
      <Link to="/configuracion" style={{ color: 'white' }}>Configuración</Link>
    </nav>
  );
}
