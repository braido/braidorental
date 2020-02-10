import React, { useState } from 'react'
import * as api from '../../api/locacao';

const AddCarroForm = props => {
	const initialFormState = { id: null, marca: '', modelo: '', placa: '', valorDiario: 0 }
	const [ carro, setCarro ] = useState(initialFormState)

	const handleInputChange = event => {
		const { name, value } = event.target

		setCarro({ ...carro, [name]: value })
	}

	return (
		<form
			onSubmit={event => {
				event.preventDefault()
				if (!carro.marca || !carro.modelo || !carro.placa || !carro.valorDiario) return

				api.addCarro(carro).then(data => {
					if (data.sucesso === true) {
						props.addCarro(data.objeto);
					}
					else {
						alert('Data not Saved');
						debugger;
					}
				})

				setCarro(initialFormState)
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
			<button>Inserir</button>
		</form>
	)
}

export default AddCarroForm
