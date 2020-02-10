import axios from 'axios';

const relatorioFaturamentoPorCarro = () => {
    return axios.get('https://localhost:32794/api/faturamento/relfaturamentoporcarro')
        .then(res => {
            let data = res.data;
            let objeto = data.objeto.itens.map(x => {
                return { ...x, ...x.carro, ...x.carro.carro, }
            })

            return { ...data, objeto: objeto };
        });
}

export { relatorioFaturamentoPorCarro}