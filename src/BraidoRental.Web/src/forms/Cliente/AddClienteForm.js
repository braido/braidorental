import React, { useState } from 'react'
import * as api from '../../api/cliente';

const AddClienteForm = props => {
	const initialFormState = { id: null, nome: '', email: '', cpf: '' }
	const [ cliente, setCliente ] = useState(initialFormState)

	const handleInputChange = event => {
		const { name, value } = event.target

		setCliente({ ...cliente, [name]: value })
	}

	return (
		<form
			onSubmit={event => {
				event.preventDefault()
				if (!cliente.nome || !cliente.cpf || !cliente.email) return

				api.addCliente(cliente).then(data => {
					if (data.sucesso === true) {
						props.addCliente(data.objeto);
					}
					else {
						alert('Data not Saved');
						debugger;
					}
				})

				setCliente(initialFormState)
			}}
		>
			<label>Nome</label>
			<input type="text" name="nome" value={cliente.nome} onChange={handleInputChange} />
			<label>Email</label>
			<input type="text" name="email" value={cliente.email} onChange={handleInputChange} />
			<label>CPF</label>
			<input type="text" name="cpf" value={cliente.cpf} onChange={handleInputChange} />
			<button>Inserir</button>
		</form>
	)
}

export default AddClienteForm
