import React, { useState, useEffect, Fragment } from 'react'
import AddCarroForm from '../forms/Carro/AddCarroForm'
import EditCarroForm from '../forms/Carro/EditCarroForm'
import CarroTable from '../tables/CarroTable'
import * as api from '../api/locacao'

const Carro = () => {

	useEffect(() => {
		(async () => {
			let res = await api.listCarro()
			setCarros(res.objeto);
		})();
	});

	// Data

	const carrosData = []

	const initialFormState = { id: null, marca: '', modelo: '', placa: '', valorDiario: 0 }

	// Setting state
	const [carros, setCarros] = useState(carrosData)
	const [currentCarro, setCurrentCarro] = useState(initialFormState)
	const [editing, setEditing] = useState(false)

	// CRUD operations
	const addCarro = carro => {
		carro.id = carros.length + 1
		setCarros([...carros, carro])
	}

	const updateCarro = (id, updatedCarro) => {
		setEditing(false)

		setCarros(carros.map(carro => (carro.id === id ? updatedCarro : carro)))
	}

	const editRow = carro => {
		setEditing(true)

		setCurrentCarro({ id: carro.id, marca: carro.marca, modelo: carro.modelo, placa: carro.placa, valorDiario: carro.valorDiario })
	}


	return (
		<div className="container">
			<h1>Cadastro de Carros</h1>
			<div className="flex-row">
				<div className="flex-large">
					{editing ? (
						<Fragment>
							<h2>Alterar Carro</h2>
							<EditCarroForm
								editing={editing}
								setEditing={setEditing}
								currentCarro={currentCarro}
								updateCarro={updateCarro}
							/>
						</Fragment>
					) : (
							<Fragment>
								<h2>Adicionar Carro</h2>
								<AddCarroForm addCarro={addCarro} />
							</Fragment>
						)}
				</div>
				<div className="flex-large">
					<h2>Visualizar Carro</h2>
					<CarroTable carros={carros} editRow={editRow} />
				</div>
			</div>
		</div>
	)
}

export default Carro
