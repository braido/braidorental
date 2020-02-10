import React, { useState, useEffect, Fragment } from 'react'
import AddClienteForm from '../forms/Cliente/AddClienteForm'
import EditClienteForm from '../forms/Cliente/EditClienteForm'
import ClienteTable from '../tables/ClienteTable'
import * as api from '../api/cliente'

const Cliente = () => {

	useEffect(() => {
		(async () => {
			let res = await api.listCliente()
			setClientes(res.objeto);
		})();
	});

	// Data

	const clientesData = []

	const initialFormState = { id: null, nome: '', email: '', cpf: '' }

	// Setting state
	const [clientes, setClientes] = useState(clientesData)
	const [currentCliente, setCurrentCliente] = useState(initialFormState)
	const [editing, setEditing] = useState(false)

	// CRUD operations
	const addCliente = cliente => {
		cliente.id = clientes.length + 1
		setClientes([...clientes, cliente])
	}

	const updateCliente = (id, updatedCliente) => {
		setEditing(false)

		setClientes(clientes.map(cliente => (cliente.id === id ? updatedCliente : cliente)))
	}

	const editRow = cliente => {
		setEditing(true)

		setCurrentCliente({ id: cliente.id, nome: cliente.nome, email: cliente.email, cpf: cliente.cpf })
	}


	return (
		<div className="container">
			<h1>Cadastro de Clientes</h1>
			<div className="flex-row">
				<div className="flex-large">
					{editing ? (
						<Fragment>
							<h2>Alterar Cliente</h2>
							<EditClienteForm
								editing={editing}
								setEditing={setEditing}
								currentCliente={currentCliente}
								updateCliente={updateCliente}
							/>
						</Fragment>
					) : (
							<Fragment>
								<h2>Adicionar Cliente</h2>
								<AddClienteForm addCliente={addCliente} />
							</Fragment>
						)}
				</div>
				<div className="flex-large">
					<h2>Visualizar Cliente</h2>
					<ClienteTable clientes={clientes} editRow={editRow} />
				</div>
			</div>
		</div>
	)
}

export default Cliente
