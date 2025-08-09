import React from 'react';

export default function ConfirmDialog({ message, onConfirm, onCancel }) {
    return (
        <div className="confirm-dialog\">
            <p>{message}</p>
            <button onClick={onConfirm}>Confirmar</button>
            <button onClick={onCancel}>Cancelar</button>
        </div>
    );
}
