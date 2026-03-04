#include <stdio.h>
#include <stdlib.h>

struct no {
    int info;         
    struct no * prox;
};

struct no * novoNo(int info) {
    struct no * novo = malloc(sizeof(struct no));
    novo->info = info;
    return novo;
}

void insert_last(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    // Precisamos encontrar o último elemento da lista. Quando encontramos, adicionamos o novo!
    struct no *curr = lista;
    while (curr->prox != NULL) {
        curr = curr->prox;
    }
    curr->prox = novo;
}

void print_list (struct no * lista){
    struct no *curr = lista;
    while (curr != NULL) {
     printf("%d\n", curr->info);
     curr = curr->prox;
    }
}

struct no *reverse_list(struct no *lista) {
    struct no *curr = lista;
    struct no *ant = NULL;
    struct no *pro = NULL;

    while (curr != NULL) {
        pro = curr->prox;   
        curr->prox = ant;   
        ant = curr;     
        curr = pro;         
    }
    return ant;  
}

int main()
{
    struct no * lista = novoNo(1);
    insert_last(lista, 2);
    insert_last(lista, 3);
    print_list(lista);
    lista = reverse_list(lista);
    print_list(lista);

    return 0;
}
