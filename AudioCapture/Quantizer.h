#pragma once

#ifndef QUANTIZER_H
# define QUANTIZER_H

struct box;

float m2[33][33][33];
long int wt[33][33][33], mr[33][33][33], mg[33][33][33], mb[33][33][33];
unsigned char *Ir, *Ig, *Ib;
int size;
int K;
unsigned short int *Qadd;

void Mark(box *cube, int label, unsigned char *tag);

int Cut(struct box *set1, struct box *set2);

float Maximize(box cube, unsigned char dir, int first, int last, int *cut, long int whole_r, long int whole_g, long int whole_b, long int whole_w);

float Var(box *cube);

long int Top(box *cube, unsigned char dir, int pos, long int mmt);

long int Bottom(box *cube, unsigned char dir, long int mmt);

long int Vol(box *cube, long int mmt);

void M3d(long int *vwt, long int *vmr, long int *vmg, long int *vmb, float *m2);

void Hist3d(long int *vwt, long int *vmr, long int *vmg, long int *vmb, float *m2);

#endif