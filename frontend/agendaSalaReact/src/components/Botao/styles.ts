import styled from "styled-components/native";
// import { RectButton } from 'react-native-gesture-handler';
import { FontAwesome5 } from '@expo/vector-icons'; 
import {  TouchableOpacity } from "react-native";

export const Button = styled(TouchableOpacity)`
    width: 150px;
    height: 55px;

    align-items: center;
    justify-content: space-evenly;
    flex-direction: row;
    margin-bottom: 5px;

    background-color: ${({ theme }) => theme.COLORS.BLUE4};
    border: 1px solid ${({theme}) => theme.COLORS.BLUE1};
    color: ${({theme}) => theme.COLORS.WHITE_100};
    box-shadow: 1px 3px 3px rgba(0,0,0,0.2);

    border-radius: 10px;
`;

export const IconEntrar = styled(FontAwesome5)`
    font-size:  25px;
    color: ${({theme}) => theme.COLORS.WHITE_100};
`;


export const Titulo = styled.Text`
    font-size: 25px;
    font-family: ${({theme}) => theme.FONTS.POPPINSLIGHT};
    color: ${({theme}) => theme.COLORS.WHITE_100};
`;