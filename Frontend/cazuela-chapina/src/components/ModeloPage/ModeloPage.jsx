import React from "react";
import { Plus, Edit, Trash2 } from "lucide-react";

function renderCellValue(val) {
  if (Array.isArray(val)) {
    // Si es array, mostrar la cantidad de elementos y una lista resumida (ejemplo: id o nombre)
    return (
      <ul className="list-disc list-inside max-h-32 overflow-auto">
        {val.length === 0 && <li>Sin elementos</li>}
        {val.map((item, idx) => (
          <li key={idx}>
            {/* Puedes personalizar qué mostrar acá, por ejemplo item.nombre o item.id */}
            {item.nombre ?? `ID: ${item.id ?? JSON.stringify(item)}`}
          </li>
        ))}
      </ul>
    );
  }

  if (typeof val === "object" && val !== null) {
    // Si es objeto, mostrar alguna propiedad si existe, o JSON pequeño
    if ("nombre" in val) return val.nombre;
    if ("id" in val) return `ID: ${val.id}`;
    return JSON.stringify(val).slice(0, 50) + (JSON.stringify(val).length > 50 ? "..." : "");
  }

  // Valor simple (string, número, booleano)
  return val?.toString();
}

export default function ModuleLayout({ title, icon: Icon, data, onAdd, onEdit, onDelete }) {
  return (
    <div className="p-6 bg-gray-50 min-h-screen">
      {/* Header */}
      <div className="flex justify-between items-center mb-6">
        <div className="flex items-center gap-3">
          <Icon className="text-blue-600" size={28} />
          <h1 className="text-2xl font-bold">{title}</h1>
        </div>
        <button
          onClick={onAdd}
          className="flex items-center gap-2 px-4 py-2 bg-blue-600 hover:bg-blue-700 text-white rounded-lg shadow-md transition"
        >
          <Plus size={20} /> Agregar
        </button>
      </div>

      {/* Table */}
      <div className="bg-white shadow-md rounded-lg overflow-x-auto">
        <table className="w-full text-left">
          <thead className="bg-gray-100 border-b">
            <tr>
              {data.length > 0 &&
                Object.keys(data[0]).map((col, i) => (
                  <th key={i} className="px-4 py-2 capitalize">
                    {col}
                  </th>
                ))}
              <th className="px-4 py-2">Acciones</th>
            </tr>
          </thead>
          <tbody>
            {data.length > 0 ? (
              data.map((row, i) => (
                <tr key={i} className="border-b hover:bg-gray-50">
                  {Object.values(row).map((val, j) => (
                    <td key={j} className="px-4 py-2">
                      {renderCellValue(val)}
                    </td>
                  ))}
                  <td className="px-4 py-2 flex gap-3">
                    <button onClick={() => onEdit(row)} className="text-yellow-500 hover:text-yellow-600">
                      <Edit size={18} />
                    </button>
                    <button onClick={() => onDelete(row)} className="text-red-500 hover:text-red-600">
                      <Trash2 size={18} />
                    </button>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td colSpan="100%" className="px-4 py-4 text-center text-gray-500">
                  No hay registros
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
