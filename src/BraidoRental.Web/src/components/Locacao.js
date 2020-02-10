import React, { useState, useEffect, Fragment } from 'react'
import LocacaoForm from '../forms/Locacao/LocacaoForm'
import LocacaoTable from '../tables/LocacaoTable'
import * as api from '../api/locacao'

const Locacao = () => {

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
	
	const editRow = carro => {
		setEditing(true)

		setCurrentCarro({ id: carro.id, marca: carro.marca, modelo: carro.modelo, placa: carro.placa, valorDiario: carro.valorDiario })
	}

	return (
		<div className="container">
			<h1>Locaçao de Carros</h1>
			<div className="flex-row">
				<div className="flex-large">
					<Fragment>
						<h2>Alterar Carro</h2>
						<LocacaoForm
							editing={editing}
							setEditing={setEditing}
							currentCarro={currentCarro}
						/>
					</Fragment>
				</div>
				<div className="flex-large">
					<h2>Carros</h2>
					<LocacaoTable carros={carros} editRow={editRow} />
				</div>
			</div>
		</div>
	)
}

export default Locacao
