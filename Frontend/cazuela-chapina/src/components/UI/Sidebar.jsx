import React from 'react';
import { Link } from 'react-router-dom';

export default function Sidebar() {
  return (
    <aside style={{ width: '200px', background: '#eee', padding: '1rem' }}>
      <ul style={{ listStyle: 'none', padding: 0 }}>
        <li><Link to="/tamales">Tamales</Link></li>
        <li><Link to="/bebidas">Bebidas</Link></li>
        <li><Link to="/combos">Combos</Link></li>
        <li><Link to="/inventario">Inventario</Link></li>
        <li><Link to="/ventas">Ventas</Link></li>
        <li><Link to="/sucursales">Sucursales</Link></li>
      </ul>
    </aside>
  );
}
