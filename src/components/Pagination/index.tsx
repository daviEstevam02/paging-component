import { useCallback, useEffect, useState } from "react";
import {  Container } from "./styles";

import { RxDoubleArrowLeft, RxDoubleArrowRight, RxChevronLeft, RxChevronRight } from "react-icons/rx"

interface Pagination {
  action: any;
  count: number
}

export function Pagination({ action, count }: Pagination){
  const [currentPage, setCurrentPage] = useState(0);

  const itensPerPage = 5;

  const changePage = (skip: number) =>{
  action(skip, itensPerPage)

  if (skip > 0) {
    setCurrentPage(skip/itensPerPage)
  } 
  else {
    setCurrentPage(0)
  }
  }
  
  let pages = count / 5;
  if (count % 5 > 0) {
    pages = Math.trunc(pages);
    pages++;
  }

  return(
    <Container
      index={currentPage}
    >
       {
        currentPage > 0 &&(
          <>
              <button onClick={() => changePage(0)}>
                <RxDoubleArrowLeft size={12} />
              </button>
              <button onClick={() => changePage(currentPage * itensPerPage - itensPerPage)}>
                <RxChevronLeft size={12} />
              </button>
          </>
        )
       }
          {[...Array(pages)].map((x, i) => {
                if (i > currentPage - 3 && i < currentPage + 3) {
                  return (
                      <button 
                      className={`button-${i}`}
                      key={i + 1}
                      onClick={() => changePage(i * itensPerPage)}
                      disabled={ i === currentPage }
                    >
                      {i + 1}
                    </button>
                  );
                }
              })}
              {
                currentPage < pages - 1 && (
                  <>
                    <button
                      onClick={() => changePage((currentPage + 1) * itensPerPage)}
                    >
                      <RxChevronRight size={12} />
                    </button>
                  <button
                    onClick={() => changePage(itensPerPage* (pages - 1))}
                    >
                    <RxDoubleArrowRight size={12} />
                  </button>
                  </>
                )
              }
               
            
    </Container>
  )
}