import React from 'react';
import { View, TouchableOpacity } from 'react-native';

import { Botao } from '../../components/Botao';
import { useLogin } from '../../contexts/contextoLogin';

// import {
//     Container,
//     ContainerHeader,
//     ContainerBody,
//     ContainerFooter
// } from './styles';


const Agendamento: React.FC = () => {

    const { fazerLogout } = useLogin();

    return (
        <View></View>
        // <Container>
        //     <ContainerHeader>
                
        //     </ContainerHeader>

        //     <ContainerBody>

        //     </ContainerBody>

        //     <ContainerFooter>
        //         <Botao  
        //             iconName='door-closed'
        //             titulo='Sair'                   
        //             onPress={() => fazerLogout() }
        //         />
        //     </ContainerFooter>
        // </Container>
    );
};

export default Agendamento;