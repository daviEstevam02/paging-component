
import { useEffect, useState } from "react";
import {  Container } from "./styles";

import { RxDoubleArrowLeft, RxDoubleArrowRight, RxChevronLeft, RxChevronRight } from "react-icons/rx"

interface Pagination {
  action: any;
  count: number
}

export function Pagination({ action, count }: Pagination){
   const [currentPage, setCurrentPage] = useState(1);

   const itensPerPage = 5;

   useEffect(() => {
      action(currentPage - 1,itensPerPage)
   },[currentPage])

   const handlePageChange = (pageNumber: number) => {
      setCurrentPage(pageNumber)
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
      <button
       onClick={() => handlePageChange(0)}
      >
          <RxDoubleArrowLeft size={12} />
        </button>
        <button
        onClick={() => handlePageChange(currentPage - 1)}
        >
          <RxChevronLeft size={12} />
        </button>
          {[...Array(pages)].map((x, i) => {
                if (i > currentPage - 3 && i < currentPage + 3) {
                  return (
                      <button 
                      className={`button-${i}`}
                      key={i + 1}
                      onClick={() => handlePageChange(i)}
                      disabled={ i === currentPage }
                    >
                      {i}
                    </button>
                  );
                }
              })}
                <button
                  onClick={() => handlePageChange(currentPage + 1)}
                >
                  <RxChevronRight size={12} />
                </button>
               <button
                onClick={() => handlePageChange(pages)}
                >
                <RxDoubleArrowRight size={12} />
              </button>
            
    </Container>
  )
}