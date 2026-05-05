#include <stdio.h>
#include <stdlib.h>

typedef struct No{
    int valor;
    struct No* esq;
    struct No* dir;
} No;

No * criarNo(int v){
    No * novo = (No*)malloc(sizeof(No));
    novo -> valor = v; 
    return novo;
}

No * inserir(int v, No * raiz){
    if(raiz == NULL){
       return criarNo(v);
    }
    if(v > raiz -> valor){
        raiz -> dir = inserir(v, raiz -> dir);
    } else{
        raiz -> esq = inserir(v, raiz -> esq);
    }
    return raiz;
}

No * buscar(int v, No * raiz){
    if(raiz == NULL || raiz -> valor == v) return raiz;
    if(v > raiz -> valor){
        return buscar(v, raiz -> dir);
    }else{
        return buscar(v, raiz -> esq);
    }
}

void imprimir_ordenado(No * raiz){
    if (raiz == NULL) return;
    imprimir_ordenado(raiz->esq);
    printf("%d ", raiz->valor);
    imprimir_ordenado(raiz->dir);
}

void apagar(int v, No * raiz){
    
}

int main()
{
    No * raiz = NULL;
    raiz = inserir(50, raiz);
    No * esquerda = inserir(30, raiz);
    No * direita = inserir(70, raiz);
    
    No* raizB = buscar(70, raiz);
    
    printf("Raiz: %d\n", raiz -> valor);
    printf("No Esquerda: %d\n", raiz -> esq -> valor);
    printf("No Direita: %d\n", raiz -> dir -> valor);
    printf("Busquei No Direita: %d\n", raizB -> valor);
    
    imprimir_ordenado(raiz);
    return 0;
}
