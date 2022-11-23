# BibliotecaEmprestimos

##Ideia de criação de um sistema de emprestimo de livros de uma biblioteca

- Cenario: um Leitor entra na bibliote, escolhe um livro, para emprestimo, informando o prazo que tera o livro em sua posse.
  O sistema guarda as informações do emprestimo, como data do emprestimo, e data da devolução do livro bem como o Leitor que está com o livro e o titulo do livro.

- Quando um livro for emprestado a um leitor não pode ser emprestado a outro sem que seja devolvido.
  Um livro só pode ser emprestado a um leitor por vez, e um leitor pode receber muitos livros

* Onde um leitor empresta um livro por um número de dias e a vai monitorando se o livro já foi devolvido
  Caso passe do prazo envia uma notificação ao quem tem o livro em sua posse
  O pagamento do empréstimo do livro é no momento da devolução

* criar uma viewModel para o caso dos emprestimos para limitar ao maximo o acesso o front ao model da seguinte forma no body da api do emprestimo será passado apenas o numero de dias que o livro vai ser emprestado.
  a data do emprestimo será sempre a data do registo (Now), e a data da devolução será sempre a data actual mais o numero de dias.

* quanto ao pagamento tenho que pensar um pouco mais pois o pagamento será realizado no dia de devolução do livro com alguma condiçoes.
  se o livro voltou como foi será pago um valor x; caso o livro volte com uma falha sera acrescentado a esse valor uma multa de 50% do valor do Emprestimo. caso tenha passado do prezo da entrega será acrescido 5% a cada dia.
