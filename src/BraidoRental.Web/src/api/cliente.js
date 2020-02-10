import axios from 'axios';

const addCliente = (cliente) => {
    return axios.post('https://localhost:32794/api/cliente/',
        {
            Id: cliente.id ?? 0,
            Nome: cliente.nome,
            Email: cliente.email,
            CPF: cliente.cpf
        })
        .then(res => res.data);
}

const listCliente = () => {
    return axios.get('https://localhost:32794/api/cliente/')
        .then(res => res.data);
}

export { addCliente, listCliente  }