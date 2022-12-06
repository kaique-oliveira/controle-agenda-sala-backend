import React from 'react';
import { View, TouchableOpacity } from 'react-native';

import { Botao } from '../../components/Botao';
import { useLogin } from '../../contexts/contextoLogin';
import { Card } from '../../components/Card';
import { Calendario } from '../../components/Calendario';

import {
    Container,
    ContainerHeader,
    ContainerBody,
    ContainerFooter
} from './styles';


const Home: React.FC = () => {

    const { fazerLogout } = useLogin();

    return (
        <Container>
            <ContainerHeader>
                
            </ContainerHeader>

            <ContainerBody>
                <Calendario/>
                <Card></Card>
            </ContainerBody>

            <ContainerFooter>
                <Botao  
                    iconName='door-closed'
                    titulo='Sair'                   
                    onPress={() => fazerLogout() }
                />
            </ContainerFooter>
        </Container>
    );
};

export default Home;