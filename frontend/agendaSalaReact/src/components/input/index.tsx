import React from 'react'
import { Ionicons } from '@expo/vector-icons';  
import {TextInputProps} from 'react-native' 
import theme from '../../styles/theme';

import { Container, InputContainer } from './styles';


interface InputProps{
  leftIcon?: boolean;
  iconName?: string;
  iconSize?: number;
  iconColor?: string;
}


const Input: React.FC<InputProps & TextInputProps> = ({ leftIcon, iconName, iconSize, iconColor, ...rest }) => {

  return (
    <Container>
      {leftIcon && (
          <Ionicons
            name={iconName}
            size={iconSize}
            color={iconColor || theme.COLORS.GRAY}
            style={{padding: 5}}
        />
      )}

      <InputContainer

      />
      
    </Container>
  )
}

export {Input};