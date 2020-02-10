import axios from 'axios';

const addCarro = (carro) => {
    return axios.post('https://localhost:32794/api/locacao/',
        {
            Id: carro.id ?? 0,
            Carro: carro.id ? undefined : {
                Marca: carro.marca,
                Modelo: carro.modelo,
                Placa: carro.placa,
            },
            ValorDiario: carro.valorDiario
        })
        .then(res => res.data);
}

const listCarro = () => {
    return axios.get('https://localhost:32794/api/locacao/')
        .then(res => {
            let data = res.data;
            let objeto = data.objeto.map(x => {
                return { ...x.carro, ...x, }
            })

            return { ...data, objeto: objeto };
        });
}

const getCarro = (id) => {
    return axios.get('https://localhost:32794/api/locacao/id/'+ id )
        .then(res => res.data);
}

const realizarAgendamento = (locacao, carro) => {
    return axios.post('https://localhost:32794/api/locacao/realizaragendamento',
        {
            IdCarro: carro.id,
            IdCliente: 1,
            DataInicio: locacao.dataInicio,
            DataFim: locacao.dataFim
        })
        .then(res => res.data);
}

const simularAgendamento = (locacao, carro) => {
    return axios.post('https://localhost:32794/api/locacao/simularagendamento',
        {
            IdCarro: carro.id,
            DataInicio: locacao.dataInicio,
            DataFim: locacao.dataFim
        })
        .then(res => res.data);
}

export { addCarro, realizarAgendamento, simularAgendamento, listCarro, getCarro }