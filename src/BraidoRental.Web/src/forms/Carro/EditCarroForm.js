import React, { useState, useEffect } from 'react'
import * as api from '../../api/locacao';

const EditCarroForm = props => {
  const [ carro, setCarro ] = useState(props.currentCarro)

  useEffect(
    () => {
      setCarro(carro)
    }
  )
  // You can tell React to skip applying an effect if certain values haven’t changed between re-renders. [ props ]

  const handleInputChange = event => {
    const { name, value } = event.target

    setCarro({ ...carro, [name]: value })
  }

  return (
    <form
      onSubmit={event => {
        event.preventDefault()

        api.addCarro(carro).then(data => {
					if (data.sucesso === true) {
						props.updateCarro(data.objeto);
					}
					else {
						alert('Data not Saved');
						debugger;
					}
				})
      }}
    >
 	    
       <label>Marca</label>
			<input type="text" name="marca" value={carro.marca} onChange={handleInputChange} />
			<label>Modelo</label>
			<input type="text" name="modelo" value={carro.modelo} onChange={handleInputChange} />
			<label>Placa</label>
			<input type="text" name="placa" value={carro.placa} onChange={handleInputChange} />
			<label>Valor Diario</label>
			<input type="number" name="valorDiario" value={carro.valorDiario} onChange={handleInputChange} />
    
      <button>Atualizar</button>
      <button onClick={() => props.setEditing(false)} className="button muted-button">
        Cancel
      </button>
    </form>
  )
}

export default EditCarroForm
