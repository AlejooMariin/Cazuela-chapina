import React, { useState, useEffect } from "react";
import ModuleLayout from "../../components/ModeloPage/ModeloPage";
import { Coffee } from "lucide-react";
import axios from "axios";

export default function Combos() {
    
  const [bebidas, setBebidas] = useState([]);
  
    useEffect(() => {
      axios.get("http://localhost:5250/api/combos") 
        .then(res => {
          console.log("Datos recibidos de la API:", res.data);
          setBebidas(res.data)
      })
        .catch(err => console.error(err));
    }, []);
  
       return (
      <ModuleLayout
        title="Gestión de Combos"
        icon={Coffee}
        data={bebidas}
        onAdd={() => alert("Abrir modal para agregar Combo")}
        onEdit={(item) => alert("Editar Combo: " + item.nombre)}
        onDelete={(item) => alert("Eliminar Combo: " + item.nombre)}
      />
    );
}
