import React, { useState, useEffect } from "react";
import ModuleLayout from "../../components/ModeloPage/ModeloPage";
import { Coffee } from "lucide-react";
import axios from "axios";

export default function Bebidas() {

      const [bebidas, setBebidas] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5250/api/bebidas") 
      .then(res => {
        console.log("Datos recibidos de la API:", res.data);
        setBebidas(res.data)
    })
      .catch(err => console.error(err));
  }, []);

     return (
    <ModuleLayout
      title="Gestión de Bebidas"
      icon={Coffee}
      data={bebidas}
      onAdd={() => alert("Abrir modal para agregar bebida")}
      onEdit={(item) => alert("Editar bebida: " + item.nombre)}
      onDelete={(item) => alert("Eliminar bebida: " + item.nombre)}
    />
  );
}
