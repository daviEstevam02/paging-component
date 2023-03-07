import styled, { css } from "styled-components";

interface Button {
    index: number
}

export const Container = styled.div<Button>`
  position: absolute;

    right: 55px;
    bottom: -47px;

   ${ props => 
        css`
            .button-${props.index}{
                background-color: var(--color-main-green);
                color: #fff;

                :hover{
                    opacity: 1;
                }

                :disabled{
                    background-color: var(--color-main-green);
                    color: #fff;
                }
            }
        `
   }
   button{
        padding: 1rem;
        background-color: #fff;
        :hover {
            background-color: #f4f4f4;
        }
   }
`
