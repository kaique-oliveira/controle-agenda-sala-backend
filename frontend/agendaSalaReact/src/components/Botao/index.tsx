import React from 'react'
import { TouchableOpacityProps } from 'react-native';
import { Button, IconEntrar, Titulo} from './styles';
import { FontAwesome5 } from '@expo/vector-icons'; 


interface Props extends TouchableOpacityProps{
    titulo: string;
    iconName: React.ComponentProps<typeof FontAwesome5>["name"];
}


const Botao: React.FC<Props> = ({titulo, iconName, ...rest }) => {
    return (
        <Button {...rest} activeOpacity={0.7}>    
            <IconEntrar name={iconName}/>
            <Titulo>{titulo}</Titulo>
        </Button>
    );
};

export { Botao };