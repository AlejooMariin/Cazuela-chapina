import React, { useState, useEffect } from "react";
import ModuleLayout from "../components/ModeloPage/ModeloPage";
import { Coffee } from "lucide-react";
import axios from "axios";

export default function Ventas() {
    
  const [bebidas, setBebidas] = useState([]);
  
    useEffect(() => {
      axios.get("http://localhost:5250/api/ventas") 
        .then(res => {
          console.log("Datos recibidos de la API:", res.data);
          setBebidas(res.data)
      })
        .catch(err => console.error(err));
    }, []);
  
       return (
      <ModuleLayout
        title="Registro de Ventas"
        icon={Coffee}
        data={bebidas}
        onAdd={() => alert("Abrir modal para agregar Tamal")}
        onEdit={(item) => alert("Editar Tamal: " + item.nombre)}
        onDelete={(item) => alert("Eliminar Tamal: " + item.nombre)}
      />
    );
}
