import React from 'react';

export default function Modal({ children, onClose }) {
    return (
        <div className="modal\">
            <div className="modal-content\">
                <button onClick={onClose}>Cerrar</button>
                {children}
            </div>
        </div>
    );
}
