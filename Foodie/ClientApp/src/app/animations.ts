import { trigger, transition, style, query, animateChild, group, animate } from "@angular/animations";

/*          SCREEN SLIDE ANIMATIONS         */

const slideLeft = [
    style({ position: 'relative' }),
    query(':enter, :leave', [
      style({
        position: 'absolute',
        top: 0,
        left: 0,
        width: '100%'
      })
    ]),
    query(':enter', [
      style({left: '100%'})
    ]),
    query(':leave', animateChild()),
    group([
      query(':leave', [
        animate('200ms ease-out', style({ left: '-100%'}))
      ]),
      query(':enter', [
        animate('200ms ease-out', style({ left: '0%'}))
      ])
    ]),
    // query(':enter', animateChild()),
  ];

  const slideRight = [
    style({ position: 'relative' }),
    query(':enter, :leave', [
      style({
        position: 'absolute',
        left: 0,
        width: '100%',
        height: 'auto'
      })
    ]),
    query(':enter', [
      style({ left: '-100%'})
    ]),
    query(':leave', animateChild()),
    group([
      query(':leave', [
        animate('200ms ease-out', style({ 
            left: '100%'
          }))
      ]),
      query(':enter', [
        animate('200ms ease-out', style({ left: '0%'}))
      ])
    ]),
    query(':enter', animateChild()),
  ]

export const slideInAnimation =
  trigger('routeAnimations', [
    transition('HomePage => MealsPage', slideLeft),
    transition('HomePage => DataPage' ,  slideRight),
    transition('DataPage => HomePage', slideLeft),
    transition('DataPage => MealsPage', slideLeft),
    transition('MealsPage => HomePage', slideRight),
    transition('MealsPage => DataPage' ,  slideRight)
  ]);

/*          FLOATING BUTTON ANIMATIONS         */
const fadeOut = [
  query(':enter', [
    style({ opacity: 0})
  ]),
  query('in', [
    style({ opacity: 1})
  ]),
]

export const fadeAnimation =
  trigger('buttonAnimations', [
    transition('void => *', fadeOut),
  ]);